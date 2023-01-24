package es.fumpa.Centralita.model;

import jakarta.persistence.*;

@Entity
public class Registro {
    @Id
    @GeneratedValue(strategy = GenerationType.IDENTITY)
    @Column(name = "id", nullable = false)
    private Long id;
    private String contacto_persona;
    private String email;
    private String empresa;
    private String fecha_hora;
    private String motivo;
    private String nombre_persona;
    private String observaciones;
    @ManyToOne
    private Usuario atendido_por;
    @ManyToOne
    private Usuario empleado;


    public Registro( String contacto_persona, String email, String empresa, String fecha_hora, String motivo, String nombre_persona, String observaciones, Usuario atendido_por, Usuario empleado) {
        this.contacto_persona = contacto_persona;
        this.email = email;
        this.empresa = empresa;
        this.fecha_hora = fecha_hora;
        this.motivo = motivo;
        this.nombre_persona = nombre_persona;
        this.observaciones = observaciones;
        this.atendido_por = atendido_por;
        this.empleado = empleado;
    }

    public Registro() {
    }

    public Long getId() {
        return id;
    }
    public void setId(Long id) {
        this.id = id;
    }

    public String getContacto_persona() {
        return contacto_persona;
    }

    public void setContacto_persona(String contacto_persona) {
        this.contacto_persona = contacto_persona;
    }

    public String getEmail() {
        return email;
    }

    public void setEmail(String email) {
        this.email = email;
    }

    public String getEmpresa() {
        return empresa;
    }

    public void setEmpresa(String empresa) {
        this.empresa = empresa;
    }

    public String getFecha_hora() {
        return fecha_hora;
    }

    public void setFecha_hora(String fecha_hora) {
        this.fecha_hora = fecha_hora;
    }

    public String getMotivo() {
        return motivo;
    }

    public void setMotivo(String motivo) {
        this.motivo = motivo;
    }

    public String getNombre_persona() {
        return nombre_persona;
    }

    public void setNombre_persona(String nombre_persona) {
        this.nombre_persona = nombre_persona;
    }

    public String getObservaciones() {
        return observaciones;
    }

    public void setObservaciones(String observaciones) {
        this.observaciones = observaciones;
    }

    public Usuario getAtendido_por() {
        return atendido_por;
    }

    public void setAtendido_por(Usuario atendido_por) {
        this.atendido_por = atendido_por;
    }

    public Usuario getempleado() {
        return empleado;
    }

    public void setempleado(Usuario empleado) {
        this.empleado = empleado;
    }

    @Override
    public String toString() {
        return "Registros{" +
                "id=" + id +
                ", contacto_persona='" + contacto_persona + '\'' +
                ", email='" + email + '\'' +
                ", empresa='" + empresa + '\'' +
                ", fecha_hora='" + fecha_hora + '\'' +
                ", motivo='" + motivo + '\'' +
                ", nombre_persona='" + nombre_persona + '\'' +
                ", observaciones='" + observaciones + '\'' +
                ", atendido_por=" + atendido_por +
                ", empleado=" + empleado +
                '}';
    }
}
